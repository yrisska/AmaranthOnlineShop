import { ProductPagedQuery, useGetPagedProductsQuery, useGetProductCategoriesQuery } from "@amaranth-online-shop.react-app/redux";
import { Grid, useMediaQuery, useTheme, Typography, CircularProgress, Pagination, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, FormLabel, RadioGroup, FormHelperText, FormControlLabel, Radio, Button } from "@mui/material";
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
    isLoading: productsIsLoading,
    isSuccess: productsIsSuccess,
    isError: productsIsError,
    error: productsError
  } = useGetPagedProductsQuery(productPagedQuery);

  const {
    data: productCategories,
    isLoading: productCategoriesIsLoading,
    isSuccess: productCategoriesIsSuccess,
    isError: productCategoriesIsError,
    error: productCategoriesError
  } = useGetProductCategoriesQuery();

  const handleChangePage = useCallback((event: ChangeEvent<unknown>, page: number) => {
    setProductPagedQuery((prevState) => ({ ...prevState, pageIndex: "" + page }));
    window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
  }, []);

  const handleSelectSortChange = useCallback((event: SelectChangeEvent) => {
    const columnAndOrder = event.target.value.split(" ");
    setProductPagedQuery((prevState) => ({ ...prevState, sortingColumnName: columnAndOrder[0], sortDirection: columnAndOrder[1] }));
  }, []);

  const handleCategoryChange = useCallback((event: React.ChangeEvent<HTMLInputElement>, value: string) => {
    if (productPagedQuery.productCategory === value) {
      return;
    }
    setProductPagedQuery((prevState) => ({ ...prevState, productCategory: value, pageIndex: "1" }));
  }, [],);

  const handleClearFilters = useCallback(() => {
    setProductPagedQuery((prevState) => ({ ...prevState, productCategory: "", pageIndex: "1" }));
  }, [],);

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
          justifyContent="flex-start"
        >
          <Grid
            item
            lg={3.2}
          >

          </Grid>
          <Grid
            container
            item
            lg={5.3}
            xs={11}
            justifyContent="space-between"
            alignItems="center"
          >
            {!isDownLg &&
              <Button
                variant="outlined"
                color="error"
                size="medium"
                sx={{
                  height: "60%",
                  textTransform: "none",
                }}
                onClick={handleClearFilters}
              >
                Clear filters
              </Button>
            }
            <FormControl>
              <InputLabel id="sort-select-label">Sort</InputLabel>
              <Select
                labelId="sort-select-label"
                id="sort-select"
                value={productPagedQuery.sortingColumnName ?
                  productPagedQuery.sortingColumnName + " " + productPagedQuery.sortDirection
                  : "id asc"
                }
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
          justifyContent="flex-start"
        >
          {
            !isDownLg &&
            <Grid
              item
              lg={2.4}
            >

            </Grid>
          }
          {!isDownLg &&
            <Grid
              container
              item
              direction="column"
              component="form"
              lg={1.5}
              alignContent="flex-end"
              textAlign="end"
            >
              {
                !productCategoriesIsLoading && productCategoriesIsSuccess && productCategories &&
                <FormControl>
                  <FormLabel id="radio-categories">Category : </FormLabel>
                  <RadioGroup
                    aria-labelledby="radio-categories"
                    name="radio-buttons-group"
                    onChange={handleCategoryChange}
                    value={productPagedQuery.productCategory || ""}
                  >
                    {productCategories.map(x => (
                      <FormControlLabel
                        key={x.id}
                        value={x.name}
                        control={<Radio  />}
                        label={x.name}
                        labelPlacement="start"
                      />
                    ))}
                  </RadioGroup>
                </FormControl>
              }
            </Grid>
          }
          <Grid
            container
            item
            lg={5}
            xs={12}
            direction="column"
            alignItems="center"
            height="fit-content"
            justifyContent={"center"}
          >
            {
              productsIsLoading &&
              <CircularProgress />
            }
            {
              !productsIsLoading && productsIsSuccess && pagedProducts &&
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
              !productsIsLoading && productsIsSuccess && !pagedProducts &&
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