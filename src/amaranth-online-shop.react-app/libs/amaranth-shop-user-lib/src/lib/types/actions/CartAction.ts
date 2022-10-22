import { ProductDto } from "../dtos";

export type CartAction =
  | { type: "add-item"; payload: ProductDto }
  | { type: "remove-item"; payload: number }
  | { type: "increment-quantity"; payload: number }
  | { type: "decrement-quantity"; payload: number }