export enum OrderStatusEnum {
  OrderPaymentDue = "Awaiting payment",
  OrderPaymentFailed = "Payment failed",
  OrderPaymentSucceeded = "Payment succefull",
  OrderDelivered = "Delivered",
}
export const getColorFromEnum = (value: string): string => {
  switch (value) {
    case "OrderPaymentDue":
      return "#C5C3D1";
    case "OrderPaymentFailed":
      return "#DDBDB8";
    case "OrderPaymentSucceeded":
      return "#76BB87";
    case "OrderDelivered":
      return "#76BB87";
    default:
      return "#DDBDB8";
  }
};
// OrderPaymentDue = "#C5C3D1",
//   OrderPaymentFailed = "#DDBDB8",
//   OrderPaymentSucceeded = "#76BB87",
//   OrderDelivered = "#76BB87",