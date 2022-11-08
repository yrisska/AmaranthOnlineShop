export type PagedResult<T> = {
  pageIndex: number,
  pageSize: number,
  total: number,
  totalPages: number,
  hasPreviousPage: boolean,
  hasNextPage: boolean,
  items: Array<T>
};