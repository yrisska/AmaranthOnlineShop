import { apiSlice } from "../api";
import {
  PagedResult, ProductCategoryDto, ProductCategoryPagedQuery
} from "../types";

export const productCategoriesApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getPagedProductCategories: builder.query<PagedResult<ProductCategoryDto>, ProductCategoryPagedQuery>({
      query: (query: ProductCategoryPagedQuery) => ({
        url: "/product-category/paginated-search",
        params: new URLSearchParams(query)
      })
    }),
    getProductCategoryById: builder.query<ProductCategoryDto, number>({
      query: (id: number) => ({
        url: `/product-category/${id}`
      })
    }),
    getManyProductCategories: builder.query<ProductCategoryDto[],(string | number)[]>({
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
      }
    }),
  })
});

export const { useGetPagedProductCategoriesQuery, useGetProductCategoryByIdQuery, useGetManyProductCategoriesQuery } = productCategoriesApiSlice;