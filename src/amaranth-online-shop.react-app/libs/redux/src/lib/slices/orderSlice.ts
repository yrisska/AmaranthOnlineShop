import { apiSlice } from "../api";
import {
  OrderDetailDto, OrderPagedQuery, PagedResult, PostOrderResponse
} from "../types";
import { PostOrderRequest } from "../types/requests";

export const ordersApiSlice = apiSlice.injectEndpoints({
  endpoints: builder => ({
    getUserOrders: builder.query<PagedResult<OrderDetailDto>, { query: OrderPagedQuery, token?: string }>({
      query: (payload: { query: OrderPagedQuery, token: string }) => ({
        url: "/orders/user-paginated-search?",
        params: new URLSearchParams(payload.query),
        headers: {
          "authorization": `Bearer ${payload.token}`
        }
      }),
    }),
    postOrder: builder.mutation<PostOrderResponse, { request: PostOrderRequest, token?: string }>({
      query: (payload: { request: PostOrderRequest, token?: string }) => ({
        url: "/orders",
        method: "POST",
        body: payload.request,
        headers: payload.token ? {
          "authorization": `Bearer ${payload.token}`
        } : {}
      }),
    })
  })
});

export const { useGetUserOrdersQuery, usePostOrderMutation } = ordersApiSlice;