import { AppRouteEnum } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";
import { lazy } from "react";

const OrdersPage = lazy(() => import("../pages/OrdersPage"));

export const privateRoutes = [
  {
    element: <OrdersPage />,
    path: AppRouteEnum.ORDERS,
    isAuth: true,
  }
];