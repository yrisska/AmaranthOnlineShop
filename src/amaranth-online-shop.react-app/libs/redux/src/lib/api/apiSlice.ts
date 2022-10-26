import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { ProductPagedQuery, ProductPagedResult } from "../types";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7074/api"}),
  endpoints: builder => ({
    getPagedProducts: builder.query<ProductPagedResult, ProductPagedQuery>({
      query: (query: ProductPagedQuery) => "/products/paginated-search?" + new URLSearchParams(query)
    })
  })
});

export const { useGetPagedProductsQuery } = apiSlice;