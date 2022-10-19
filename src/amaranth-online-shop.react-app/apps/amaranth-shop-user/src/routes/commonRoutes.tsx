import { AppRouteEnum } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";
import { lazy } from "react";

const HomePage = lazy(() => import('../pages/HomePage'));
const ShopPage = lazy(() => import('../pages/ShopPage'))

export const commonRoutes = [
    {
        element: <HomePage />,
        path: AppRouteEnum.HOME,
    },
    {
        element: <ShopPage />,
        path: AppRouteEnum.SHOP,
    }
]