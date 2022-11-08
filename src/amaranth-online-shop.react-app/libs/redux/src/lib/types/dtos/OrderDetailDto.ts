import { OrderStatusEnum } from "../enums/OrderStatusEnum";
import { OrderItem } from "./OrderItem";

export type OrderDetailDto = {
  id: number,
  total: number,
  orderItems: OrderItem[],
  status: OrderStatusEnum,
  fullName: string,
  email: string,
  phone: string,
  adress: string,
  comments: string
};