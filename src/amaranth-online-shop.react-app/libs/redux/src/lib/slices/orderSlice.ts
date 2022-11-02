import { apiSlice } from "../api";
import { PostOrderResponse } from "../types";
import { PostOrderRequest } from "../types/requests";

export const ordersApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    postOrder: builder.mutation<PostOrderResponse, {request: PostOrderRequest, token?: string}>({
      query: (options: {request: PostOrderRequest, token?: string}) => ({
        url: "/orders",
        method: "POST",
        body: options.request,
        headers: options.token ? {
          "authorization": `Bearer ${options.token}`
        } : {}
      }),
    })
  })
});

export const { usePostOrderMutation } = ordersApiSlice;