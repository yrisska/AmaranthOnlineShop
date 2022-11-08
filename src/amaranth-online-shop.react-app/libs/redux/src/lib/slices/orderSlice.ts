import { apiSlice } from "../api";
import {
  OrderDetailDto, OrderPagedQuery, PagedResult, PostOrderResponse
} from "../types";
import { PostOrderRequest } from "../types/requests";

export const ordersApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getUserOrders: builder.query<PagedResult<OrderDetailDto>, { query: OrderPagedQuery, token?: string }>({
      query: (options: { query: OrderPagedQuery, token: string }) => ({
        url: "/orders/user-paginated-search?",
        params: new URLSearchParams(options.query),
        headers: {
          "authorization": `Bearer ${options.token}`
        }
      }),
    }),
    postOrder: builder.mutation<PostOrderResponse, { request: PostOrderRequest, token?: string }>({
      query: (options: { request: PostOrderRequest, token?: string }) => ({
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

export const { useGetUserOrdersQuery, usePostOrderMutation } = ordersApiSlice;