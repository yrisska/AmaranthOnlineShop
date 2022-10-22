import { CartItem } from "./CartItem"

export type CartState = {
  cartItems: CartItem[],
  totalQuantity: number,
  totalPrice: number,
}