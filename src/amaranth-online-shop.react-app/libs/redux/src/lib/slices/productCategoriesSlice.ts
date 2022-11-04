import { apiSlice } from "../api";
import { ProductCategoryDto } from "../types";

export const productCategoriesApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getProductCategories: builder.query<ProductCategoryDto[], void>({
      query: () => "/product-category"
    })
  })
});

export const { useGetProductCategoriesQuery } = productCategoriesApiSlice;