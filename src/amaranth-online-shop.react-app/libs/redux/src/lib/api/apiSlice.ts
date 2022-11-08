import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { 
  PagedResult, ProductDto, ProductPagedQuery 
} from "../types";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7074/api"}),
  endpoints: builder => ({
    getPagedProducts: builder.query<PagedResult<ProductDto>, ProductPagedQuery>({
      query: (query: ProductPagedQuery) => ({
        url: "/products/paginated-search?",
        params: new URLSearchParams(query)
      })
    })
  })
});

export const { useGetPagedProductsQuery } = apiSlice;