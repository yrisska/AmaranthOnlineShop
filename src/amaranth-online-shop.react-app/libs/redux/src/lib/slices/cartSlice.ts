import { createSelector, createSlice, PayloadAction, Selector } from "@reduxjs/toolkit";
import currency from "currency.js";
import { RootState } from "../store";
import { ProductDto, CartItem } from "../types";

export interface CartState {
  items: CartItem[],
}

const initialState: CartState = {
  items: []
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    cartAddItem: (state, action: PayloadAction<ProductDto>) => {
      const cartItem = state.items.find(x => x.product.id === action.payload.id);
      if (cartItem) {
        cartItem.quantity++;
        cartItem.totalPrice = currency(cartItem.totalPrice).add(cartItem.product.price).value;
      }
      else {
        state.items.push({ product: action.payload, quantity: 1, totalPrice: currency(action.payload.price).value });
      }
    },
    cartRemoveItem: (state, action: PayloadAction<number>) => {
      state.items = state.items.filter(x => x.product.id !== action.payload);
    },
    cartRemoveAll: (state) => {
      state.items = [];
    },
    cartIncrementItem: (state, action: PayloadAction<number>) => {
      const cartItem = state.items.find(x => x.product.id === action.payload);
      if (cartItem) {
        cartItem.quantity++;
        cartItem.totalPrice = currency(cartItem.totalPrice).add(cartItem.product.price).value;
      }
    },
    cartDecrementItem: (state, action: PayloadAction<number>) => {
      const cartItem = state.items.find(x => x.product.id === action.payload);
      if (cartItem) {
        cartItem.quantity--;
        cartItem.totalPrice = currency(cartItem.totalPrice).subtract(cartItem.product.price).value;
      }
    },
  }
});

export const selectCartItems = (state: RootState) => state.cart.items;

export const selectCartTotalQuantity = (state: RootState) => state.cart.items.reduce((x, y) => x + y.quantity, 0);

export const selectCartTotalPrice = (state: RootState) => {
  return state.cart.items.reduce((x, y) => x.add(
    y.quantity === 1 ? currency(y.product.price) : currency(y.product.price).multiply(y.quantity)
  ), currency(0));
}

export const { cartAddItem, cartRemoveItem, cartRemoveAll, cartIncrementItem, cartDecrementItem } = cartSlice.actions;

export default cartSlice.reducer;