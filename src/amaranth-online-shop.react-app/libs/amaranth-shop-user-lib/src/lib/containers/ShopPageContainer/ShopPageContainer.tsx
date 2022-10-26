import { ProductPagedQuery, useGetPagedProductsQuery } from "@amaranth-online-shop.react-app/redux";
import { Grid, useMediaQuery, useTheme, Typography, CircularProgress, Pagination } from "@mui/material";
import { ChangeEvent, useCallback, useState } from "react";
import ProductList from "../../components/common/ProductList/ProductList";
import { PageLayout } from "../../layout";
import { AppRouteEnum } from "../../types";

export const ShopPageContainer = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));

  const [productPagedQuery, setProductPagedQuery] = useState<ProductPagedQuery>({});

  const {
    data: pagedProducts,
    isLoading,
    isSuccess,
    isError,
    error
  } = useGetPagedProductsQuery(productPagedQuery);

  const handleChangePage = useCallback((event: ChangeEvent<unknown>, page: number) => {
    setProductPagedQuery((prevState) => ({ ...prevState, pageIndex: "" + page }));
    window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
  }, []);

  return (
    <PageLayout
      currentPage={AppRouteEnum.SHOP}
    >

      <Grid
        container
        height="160vh"
        direction="column"
        justifyContent="center"
        alignItems="center"
        width="100%"
      >
        <Grid
          container
          item
          bgcolor={theme.palette.secondary.main}
          xs={1.5}
          width="100%"
          justifyContent="center"
          alignItems="center"
        >
          <Typography
            variant="h1"
            color="primary"
          >
            Welcome to Shop!
          </Typography>
        </Grid>
        <Grid
          container
          item
          xs={0.5}
          bgcolor="orange"
          justifyContent="center"
        >
          <Grid
            container
            item
            lg={9}
            xs={12}
            bgcolor="gray"
          >

          </Grid>
        </Grid>
        <Grid
          container
          item
          xs={10}
          width={"100%"}
          justifyContent="center"
        >
          {
            !isDownLg &&
            <Grid
              container
              item
              bgcolor="blue"
              lg={1.2}
            >
              b
            </Grid>
          }
          <Grid
            container
            item
            lg={7}
            md={12}
            xs={12}
            justifyContent="center"
            alignItems="center"
          >
            <Grid
              container
              justifyContent="center"
              alignItems={isSuccess ? "flex-start" : "center"}
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
                  <ProductList
                    products={pagedProducts.items}
                  />
                  <Pagination
                    page={pagedProducts.pageIndex}
                    count={pagedProducts.totalPages}
                    onChange={handleChangePage}
                  />
                </>
              }
              {
                !isLoading && isSuccess && !pagedProducts &&
                <Typography
                  variant="h3"
                  color="initial"
                >
                  No matched products!
                </Typography>
              }
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </PageLayout>
  );
};

export default ShopPageContainer;