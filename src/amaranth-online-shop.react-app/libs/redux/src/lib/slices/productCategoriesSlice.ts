import { apiSlice } from "../api";
import {
  CreateProductCategoryRequest,
  PagedResult, ProductCategoryDto, ProductCategoryPagedQuery, UpdateProductCategoryRequest
} from "../types";

export const productCategoriesApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getPagedProductCategories: builder.query<PagedResult<ProductCategoryDto>, ProductCategoryPagedQuery>({
      query: (query: ProductCategoryPagedQuery) => ({
        url: "/product-category/paginated-search",
        params: new URLSearchParams(query)
      }),
      providesTags: ["ProductCategories"]
    }),

    getProductCategoryById: builder.query<ProductCategoryDto, number>({
      query: (id: number) => ({
        url: `/product-category/${id}`
      }),
      providesTags: ["ProductCategories"]
    }),

    getManyProductCategories: builder.query<ProductCategoryDto[], (string | number)[]>({
      query: (identifiers: number[] | string[]) => {
        const params = new URLSearchParams();
        identifiers.forEach(x => params.append(
          "identifiers",
          x.toString()
        ));
        return {
          url: "/product-category/many",
          params: params,
        };
      },
      providesTags: ["ProductCategories"]
    }),

    createProductCategory: builder.mutation<ProductCategoryDto, { data: CreateProductCategoryRequest, file?: File, token: string }>({
      query: (payload: { data: CreateProductCategoryRequest, file?: File, token?: string }) => {

        const formData = new FormData();
        Object.keys(payload.data)
          .forEach(x => formData.append(
            x,
            payload.data[x as keyof CreateProductCategoryRequest]
          ));

        if (payload.file) {
          formData.append(
            "imageFile",
            payload.file as Blob,
            payload.file.name
          );
        }

        return {
          url: "/product-category",
          method: "POST",
          body: formData,
          headers: {
            "authorization": `Bearer ${payload.token}`
          }
        };
      },
      invalidatesTags: ["ProductCategories"],
    }),

    updateProductCategory: builder.mutation<ProductCategoryDto, { data: UpdateProductCategoryRequest, file?: File, token: string }>({
      query: (payload: { data: UpdateProductCategoryRequest, file?: File, token?: string }) => {

        const formData = new FormData();
        Object.keys(payload.data)
          .forEach(x => formData.append(
            x,
            payload.data[x as keyof UpdateProductCategoryRequest]
          ));

        if (payload.file) {
          formData.append(
            "imageFile",
            payload.file as Blob,
            payload.file.name
          );
        }

        return {
          url: "/product-category",
          method: "PUT",
          body: formData,
          headers: {
            "authorization": `Bearer ${payload.token}`
          }
        };
      },
      invalidatesTags: ["ProductCategories"]
    }),

    deleteProductCategory: builder.mutation<ProductCategoryDto, { id: string, token: string }>({
      query: (payload: { id: string, token?: string }) => ({
        url: `/product-category/${payload.id}`,
        method: "DELETE",
        headers: {
          "authorization": `Bearer ${payload.token}`
        }
      }),
      invalidatesTags: ["ProductCategories"]
    }),
  })
});

export const {
  useGetPagedProductCategoriesQuery,
  useGetProductCategoryByIdQuery,
  useGetManyProductCategoriesQuery,
  useCreateProductCategoryMutation,
  useUpdateProductCategoryMutation,
  useDeleteProductCategoryMutation,
} = productCategoriesApiSlice;