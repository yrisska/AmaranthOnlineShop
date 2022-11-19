import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { environment } from "../environments/environment";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: environment.apiUrl }),

  tagTypes: ["Products", "ProductCategories", "Orders"],

  endpoints: builder => ({
  }),
});