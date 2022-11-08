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
        >
          <Box
            component={"img"}
            src="https://es.com.ua/media/catalog/product/placeholder/default/default-product-image.png?auto=webp&format=png&width=2560&height=3200&fit=cover"
            sx={{
              aspectRatio: "1",
              width: "75%",
              maxWidth: "23vmin",
              height: "auto",
            }}
          />
          <Typography
            variant="h6"
            color="initial"
          >
            {product.name}
          </Typography>
          <Typography
            variant="body1"
            color="initial"
          >
            {product.description}
          </Typography>
          <Grid
            container
            item
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