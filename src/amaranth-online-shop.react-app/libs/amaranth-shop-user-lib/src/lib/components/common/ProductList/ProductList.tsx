import { cartAddItem, useAppDispatch } from "@amaranth-online-shop.react-app/redux";
import { Box, CircularProgress, Grid, Pagination, Typography, IconButton, useTheme, Paper } from "@mui/material";
import currency from "currency.js";
import { FC } from "react";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";
import { ProductListProps } from "./ProductList.types";
import { productListStyles } from "./ProductList.styles";

const ProductList: FC<ProductListProps> = ({
  products
}) => {
  const theme = useTheme();
  const isDownLg = theme.breakpoints.down("lg");
  const dispatch = useAppDispatch();

  return (
    <Grid
      {...productListStyles.root}
      height={isDownLg ? "auto" : "90%"}
      width={isDownLg ? "100%" : "70%"}
      columnGap={isDownLg ? "2vh" : "5vh"}
      paddingLeft="2vh"
    >
      {products.map(product =>
        <Grid
          key={product.id}
          component={Paper}
          container
          item
          justifyContent="space-around"
          alignItems="center"
          direction="column"
          height="35vh"
          lg={3.5}
          xs={5.5}
          overflow="hidden"
        >
          <Grid
            container
            item
            lg={2}
            xs={3}
            height="100%"
            alignItems="center"
            justifyContent="center"
          >
            <Box
              component={"img"}
              src={product.imageUri}
              sx={{
                objectFit: "scale-down",
                aspectRatio: "1",
                width: "75%",
                maxWidth: "23vmin",
                height: "auto",
                maxHeight: "90%",
              }}
            />
          </Grid>
          <Grid
            container
            item
            lg={2}
            xs={2}
            alignItems="center"
            justifyContent="center"
          >
            <Typography
              variant="h6"
              color="initial"
            >
              {product.name}
            </Typography>
          </Grid>
          <Grid
            container
            item
            lg={2}
            xs={2}
            alignItems="center"
            justifyContent="center"
          >
            <Typography
              variant="body1"
              color="initial"
              align="center"
            >
              {
                product.description.length < 40 ?
                  product.description :
                  product.description.slice(0, 40) + "..."
              }
            </Typography>
          </Grid>
          <Grid
            container
            item
            xs={2}
            width="70%"
            justifyContent="space-around"
            alignItems="center"
          >
            <Typography
              variant="h6"
              color="initial"
            >
              {currency(product.price).format()}
            </Typography>
            <IconButton
              aria-label=""
              onClick={() => dispatch(cartAddItem(product))}
            >
              <ShoppingCartOutlinedIcon style={{ color: theme.palette.primary.dark }} />
            </IconButton>
          </Grid>
        </Grid>
      )}
    </Grid>
  );
};

export default ProductList;