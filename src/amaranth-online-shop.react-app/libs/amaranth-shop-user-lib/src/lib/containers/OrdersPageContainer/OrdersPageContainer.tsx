import { OrderPagedQuery, useGetUserOrdersQuery } from "@amaranth-online-shop.react-app/redux";
import { useAuth0 } from "@auth0/auth0-react";
import { CircularProgress, Grid, Pagination, Typography, useMediaQuery, useTheme } from "@mui/material";
import { Console } from "console";
import { ChangeEvent, useCallback, useEffect, useState } from "react";
import OrderList from "../../components/common/OrderList/OrderList";
import { PageLayout } from "../../layout";
import { AppRouteEnum } from "../../types";

export const OrdersPageContainer = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));

  const [orderPagedQuery, setOrderPagedQuery] = useState<OrderPagedQuery>({pageSize: "5"});
  const [token, setToken] = useState<string | null>(null);
  const { getAccessTokenSilently } = useAuth0();

  useEffect(() => {
    loadToken();

  }, []);

  const loadToken = async () => {
    const tokenResponse = await getAccessTokenSilently();
    setToken(tokenResponse);
  };

  const {
    data: pagedOrders,
    isLoading: ordersIsLoading,
    isSuccess: ordersIsSuccess,
    isError: ordersIsError,
    error: ordersError,
    isUninitialized: ordersIsUninitialized
  } = useGetUserOrdersQuery({
    query: orderPagedQuery,
    token: token ?? "",
  },
    {
      skip: !token
    }
  );

  const handleChangePage = useCallback((event: ChangeEvent<unknown>, page: number) => {
    setOrderPagedQuery((prevState) => ({ ...prevState, pageIndex: "" + page }));
    window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
  }, []);
  console.log(orderPagedQuery);
  return (
    <PageLayout
      currentPage={AppRouteEnum.ORDERS}
    >
      <Grid
        container
        direction="column"
        height="auto"
        minHeight="80vh"
        justifyContent="flex-start"
        alignItems="center"
      >
        <Grid
          container
          item
          bgcolor={theme.palette.secondary.main}
          xs={1.4}
          width="100%"
          justifyContent="center"
          alignItems="center"
        >
          <Typography
            variant="h1"
            color="primary"
          >
            Your Orders
          </Typography>
        </Grid>
        <Grid
          item
          container
          justifyContent={(ordersIsUninitialized || ordersIsLoading || pagedOrders?.items.length === 0) ? "center" : "flex-start"}
          alignItems="center"
          direction="column"
          minHeight="60vh"
        >
          {
            (ordersIsUninitialized || ordersIsLoading) &&
            <CircularProgress />
          }
          {
            !ordersIsUninitialized && !ordersIsLoading && ordersIsSuccess && pagedOrders.items.length > 0 &&
            <>
              <OrderList orders={pagedOrders.items} />
              {
                pagedOrders.totalPages > 1 &&
                <Pagination
                  sx={{ marginTop: "4vh" }}
                  page={pagedOrders.pageIndex}
                  count={pagedOrders.totalPages}
                  onChange={handleChangePage}
                />
              }
            </>
          }
          {
            !ordersIsUninitialized && !ordersIsLoading && ordersIsSuccess && pagedOrders.items.length === 0 &&
            <Typography
              variant="h3"
              color="gray"
            >
              No orders!
            </Typography>
          }
        </Grid>
      </Grid>
    </PageLayout>
  );
};

export default OrdersPageContainer;