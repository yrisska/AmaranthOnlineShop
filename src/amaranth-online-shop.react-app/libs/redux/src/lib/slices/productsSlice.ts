import { apiSlice } from "../api";
import {
  CreateProductRequest, PagedResult, ProductDto, ProductPagedQuery, UpdateProductRequest
} from "../types";

export const productsApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getPagedProducts: builder.query<PagedResult<ProductDto>, ProductPagedQuery>({
      query: (query: ProductPagedQuery) => ({
        url: "/products/paginated-search",
        params: new URLSearchParams(query),
      }),
      providesTags: ["Products"]
    }),

    getProductById: builder.query<ProductDto, number>({
      query: (id: number) => ({
        url: `/products/${id}`
      }),
      providesTags: ["Products"]
    }),

    createProduct: builder.mutation<ProductDto, { data: CreateProductRequest, file?: File, token: string }>({
      query: (payload: { data: CreateProductRequest, file?: File, token?: string }) => {

        const formData = new FormData();
        Object.keys(payload.data)
          //.filter(x => !!payload.data[x as keyof CreateProductRequest])
          .forEach(x => formData.append(
            x,
            payload.data[x as keyof CreateProductRequest]
          ));

        if (payload.file) {
          formData.append(
            "imageFile",
            payload.file as Blob,
            payload.file.name
          );
        }

        return {
          url: "/products",
          method: "POST",
          body: formData,
          headers: {
            "authorization": `Bearer ${payload.token}`
          }
        };
      },
      invalidatesTags: ["Products"],
    }),

    updateProduct: builder.mutation<ProductDto, { data: UpdateProductRequest, file?: File, token: string }>({
      query: (payload: { data: UpdateProductRequest, file?: File, token?: string }) => {

        const formData = new FormData();
        Object.keys(payload.data)
          .forEach(x => formData.append(
            x,
            payload.data[x as keyof UpdateProductRequest]
          ));

        if (payload.file) {
          formData.append(
            "imageFile",
            payload.file as Blob,
            payload.file.name
          );
        }

        return {
          url: "/products",
          method: "PUT",
          body: formData,
          headers: {
            "authorization": `Bearer ${payload.token}`
          }
        };
      },
      invalidatesTags: ["Products"]
    }),

    deleteProduct: builder.mutation<ProductDto, { id: string, token: string }>({
      query: (payload: { id: string, token?: string }) => ({
        url: `/products/${payload.id}`,
        method: "DELETE",
        headers: {
          "authorization": `Bearer ${payload.token}`
        }
      }),
      invalidatesTags: ["Products"]
    }),
  })
});

export const {
  useGetPagedProductsQuery,
  useGetProductByIdQuery,
  useCreateProductMutation,
  useUpdateProductMutation,
  useDeleteProductMutation
} = productsApiSlice;