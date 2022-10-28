export type PostOrderRequest = {
  cartItems: CartItemRequest[],
  fullName: string,
  email: string,
  phone: string,
  adress: string,
  comments: string
};

export type CartItemRequest = {
  productId: number,
  quantity: number,
};