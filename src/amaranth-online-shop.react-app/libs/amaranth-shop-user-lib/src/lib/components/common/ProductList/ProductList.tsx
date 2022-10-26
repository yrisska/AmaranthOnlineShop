import { cartAddItem, useAppDispatch } from "@amaranth-online-shop.react-app/redux";
import { Box, CircularProgress, Grid, Pagination, Typography, IconButton, useTheme } from "@mui/material";
import currency from "currency.js";
import { FC } from "react";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";
import { ProductListProps } from "./ProductList.types";
import { productListStyles } from "./ProductList.styles";

const ProductList: FC<ProductListProps> = ({
  products
}) => {
  const theme = useTheme();
  const dispatch = useAppDispatch();

  return (
    <Grid
      {...productListStyles.root}
    >
      {products.map(product =>
        <Grid
          key={product.id}
          container
          item
          justifyContent="space-around"
          alignItems="center"
          direction="column"
          height="40vh"
          lg={4}
          sx={{

          }}
        >
          <Box
            component={"img"}
            src="https://es.com.ua/media/catalog/product/placeholder/default/default-product-image.png?auto=webp&format=png&width=2560&height=3200&fit=cover"
            sx={{
              aspectRatio: "1",
              width: "75%",
              height: "auto"
            }}
          />
          <Typography
            variant="h5"
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
          >
            <Typography
              variant="h5"
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