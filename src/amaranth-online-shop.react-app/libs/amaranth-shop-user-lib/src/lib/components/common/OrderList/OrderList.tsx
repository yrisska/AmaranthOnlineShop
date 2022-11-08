import { getColorFromEnum, OrderStatusEnum } from "@amaranth-online-shop.react-app/redux";
import { Box, Grid, Paper, Typography, useMediaQuery, useTheme } from "@mui/material";
import currency from "currency.js";
import { FC } from "react";
import { OrderListProps } from "./OrderList.types";

const OrderList: FC<OrderListProps> = ({
  orders
}) => {
  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));

  return (
    <Grid
      container
      direction="column"
      width={isDownLg? "90%" : "100%"}
      justifyContent="space-around"
      alignItems="center"
      rowGap="2vh"
      paddingTop="5vh"
    >

      {orders.map((order) => (
        <Grid
          key={order.id}
          item
          container
          width={isDownLg ? "100%" : "40%"}
          component={Paper}
          minHeight="8vh"
        >
          <Grid
            container
            item
            xs={12}
            sx={{
              "&:before": {
                width: "10px",
                height: "100%",
                background: getColorFromEnum(order.status as string),
                display: "inline-block",
                content: "''",
                marginRight: "1vh"
              }
            }}
          >
            <Grid
              container
              item
              lg={11.5}
              xs={10}
              direction={isDownLg ? "column" : "row"}
              justifyContent="space-between"
              rowSpacing={2}
              alignItems="center"
            >
              <Grid
                item
                container
                direction="column"
                xs={3}
                rowGap="1vh"
              >
                <Typography
                  variant="body2"
                  color="initial"
                >
                  Order №
                  {order.id}
                </Typography>
                <Typography
                  variant="body1"
                  color="initial"
                >
                  {OrderStatusEnum[order.status as string as keyof typeof OrderStatusEnum]}
                </Typography>
              </Grid>
              <Grid
                item
                container
                xs={2}
                direction="column"
                rowGap="1vh"
              >
                <Typography
                  variant="body2"
                  color="initial"
                >
                  Total:
                </Typography>
                <Typography
                  variant="body1"
                  color="initial"
                >
                  {currency(order.total).format()}
                </Typography>
              </Grid>
              <Grid
                item
                container
                xs={2}
                alignItems="center"
                columnGap="1vh"
              >
                <Typography
                  variant="body2"
                  color="initial"
                >
                  Total quantity:
                </Typography>
                <Typography
                  variant="body1"
                  color="initial"
                >
                  {order.orderItems.reduce((x, y) => x + y.quantity, 0)}
                </Typography>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      ))}
    </Grid>
  );
};

export default OrderList;