import currency from "currency.js"
import { ProductDto } from "../dtos"

export type CartItem = {
  product: ProductDto,
  quantity: number,
  totalPrice: number
}