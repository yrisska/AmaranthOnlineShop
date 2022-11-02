import { ProductPagedQuery, useGetPagedProductsQuery } from "@amaranth-online-shop.react-app/redux";
import { Grid, useMediaQuery, useTheme, Typography, CircularProgress, Pagination, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent } from "@mui/material";
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

  const handleSelectSortChange = useCallback((event: SelectChangeEvent) => {
    const columnAndOrder = event.target.value.split(" ");
    setProductPagedQuery((prevState) => ({ ...prevState, sortingColumnName: columnAndOrder[0], sortDirection: columnAndOrder[1] }));
  }, []);

  return (
    <PageLayout
      currentPage={AppRouteEnum.SHOP}
    >

      <Grid
        container
        height={isDownLg ? "auto" : "160vh"}
        direction="column"
        justifyContent="center"
        alignItems="center"
        width="100%"
        rowGap="1vh"
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
            Welcome to Shop!
          </Typography>
        </Grid>
        <Grid
          container
          item
          xs={0.4}
          justifyContent="center"
        >
          <Grid
            container
            item
            lg={5.8}
            xs={11}
            justifyContent="flex-end"
          >
            <FormControl>
              <InputLabel id="sort-select-label">Sort</InputLabel>
              <Select
                labelId="sort-select-label"
                id="sort-select"
                value={"id asc"}
                label="Age"
                onChange={handleSelectSortChange}
              >
                <MenuItem value={"id asc"}>By date</MenuItem>
                <MenuItem value={"price asc"}>Price: Low to High</MenuItem>
                <MenuItem value={"price desc"}>Price: High to Low</MenuItem>
              </Select>
            </FormControl>
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
            xs={12}
            direction="column"
            alignItems="center"
            height="fit-content"
            justifyContent={"center"}
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
                {
                  pagedProducts.totalPages > 1 &&
                  <Pagination
                    sx={{ marginTop: "4vh" }}
                    page={pagedProducts.pageIndex}
                    count={pagedProducts.totalPages}
                    onChange={handleChangePage}
                  />
                }
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
    </PageLayout >
  );
};

export default ShopPageContainer;