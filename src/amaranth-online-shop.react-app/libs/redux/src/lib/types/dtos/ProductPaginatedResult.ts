import { ProductDto } from "./ProductDto";

export type ProductPagedResult = {
  pageIndex: number,
  pageSize: number,
  total: number,
  totalPages: number,
  hasPreviousPage: boolean,
  hasNextPage: boolean,
  items: Array<ProductDto>
};