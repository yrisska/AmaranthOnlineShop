import { cartAddItem, ProductPagedQuery, useAppDispatch, useGetPagedProductsQuery } from '@amaranth-online-shop.react-app/redux';
import { Box, Card, CircularProgress, Grid, Pagination, Typography, Button, IconButton, useTheme } from '@mui/material'
import currency from 'currency.js';
import { useEffect, useState } from 'react'
import { getPagedProducts } from '../../../services';
import { productListStyles } from './ProductList.styles';
import ShoppingCartOutlinedIcon from '@mui/icons-material/ShoppingCartOutlined';
import { useDispatch } from 'react-redux';

const ProductList = () => {

  const [productPagedQuery, setProductPagedQuery] = useState<ProductPagedQuery>({});
  //const [pagedProducts, setPagedProducts] = useState<ProductPagedResult | null>(null);

  //const pagedProducts = useAppSelector(selectPagedProducts);

  const {
    data: pagedProducts,
    isLoading,
    isSuccess,
    isError,
    error
  } = useGetPagedProductsQuery(productPagedQuery);

  /*useEffect(() => {
    fetchPagedProducts();
  }, [productPagedQuery])

  const fetchPagedProducts = async () => {
    try {
      const fetchedPagedProducts = await getPagedProducts(productPagedQuery);

      if (fetchedPagedProducts) {
        setPagedProducts(fetchedPagedProducts);
      }
    } catch (error) {
      console.log(error);
    }
  }*/

  const handlePageChange = (event: React.ChangeEvent<unknown>, page: number) => {
    setProductPagedQuery({ ...productPagedQuery, pageIndex: '' + page })
  }
  const theme = useTheme();
  const dispatch = useAppDispatch();

  return (
    <>
      <Grid
        container
        justifyContent={isLoading ? "center" : "flex-start"}
        alignItems={isLoading ? "center" : "flex-start"}
        height="95%"
        width="100%"
      >
        {
          isLoading &&
          <CircularProgress />
        }
        {
          !isLoading && isSuccess && pagedProducts &&
          <>
            {pagedProducts.items.map(product =>
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
                <Typography variant="h5" color="initial">
                  {product.name}
                </Typography>
                <Typography variant="body1" color="initial">
                  {product.description}
                </Typography>
                <Grid
                  container
                  item
                  width="70%"
                  justifyContent="space-around"
                >
                  <Typography variant="h5" color="initial">
                    {currency(product.price).format()}
                  </Typography>
                  <IconButton aria-label="" onClick={() => dispatch(cartAddItem(product))}>
                    <ShoppingCartOutlinedIcon style={{color: theme.palette.primary.dark}}/>
                  </IconButton>
                </Grid>
              </Grid>
            )}
          </>
        }
      </Grid>
      {
        !isLoading && isSuccess && pagedProducts &&
        <Pagination
          page={pagedProducts.pageIndex}
          count={pagedProducts.totalPages}
          onChange={handlePageChange}
        />
      }
    </>

  )
}

export default ProductList