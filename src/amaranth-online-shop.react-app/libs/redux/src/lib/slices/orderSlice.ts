import { apiSlice } from "../api";
import { PostOrderRequest } from "../types/requests";

export const ordersApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    postOrder: builder.mutation({
      query: (order: PostOrderRequest) => ({
        url: "/orders",
        method: "POST",
        body: order
      }),
    })
  })
});

export const { usePostOrderMutation } = ordersApiSlice;