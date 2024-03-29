import { ProductPagedQuery, useGetPagedProductCategoriesQuery, useGetPagedProductsQuery } from "@amaranth-online-shop.react-app/redux";
import { Grid, useMediaQuery, useTheme, Typography, CircularProgress, Pagination, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, FormLabel, RadioGroup, FormHelperText, FormControlLabel, Radio, Button } from "@mui/material";
import { ChangeEvent, useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import ProductList from "../../components/common/ProductList/ProductList";
import { PageLayout } from "../../layout";
import { AppRouteEnum } from "../../types";

export const ShopPageContainer = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));

  const [productPagedQuery, setProductPagedQuery] = useState<ProductPagedQuery>({});

  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    if (!searchParams.toString()) {
      return;
    }

    const category = searchParams.get("category");
    if (category) {
      setProductPagedQuery((prevState) => ({ ...prevState, productCategory: category }));
    }
    if (searchParams.has("name")) {
      setProductPagedQuery((prevState) => ({ ...prevState, productCategory: "", pageIndex: "1", name: searchParams.get("name") || "" }));
    }
  }, [searchParams]);

  const {
    data: pagedProducts,
    isLoading: productsIsLoading,
    isSuccess: productsIsSuccess
  } = useGetPagedProductsQuery(productPagedQuery);

  const {
    data: productCategories,
    isLoading: productCategoriesIsLoading,
    isSuccess: productCategoriesIsSuccess
  } = useGetPagedProductCategoriesQuery({
    pageIndex: "1",
    pageSize: "10"
  });

  const handleChangePage = (event: ChangeEvent<unknown>, page: number) => {
    setProductPagedQuery((prevState) => ({ ...prevState, pageIndex: "" + page }));
    window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
  };

  const handleSelectSortChange = (event: SelectChangeEvent) => {
    const columnAndOrder = event.target.value.split(" ");
    setProductPagedQuery((prevState) => ({ ...prevState, sortingColumnName: columnAndOrder[0], sortDirection: columnAndOrder[1], pageIndex: "1" }));
  };

  const handleCategoryChange = (event: React.ChangeEvent<HTMLInputElement>, value: string) => {
    if (productPagedQuery.productCategory === value) {
      return;
    }
    setProductPagedQuery((prevState) => ({ ...prevState, productCategory: value, pageIndex: "1" }));
  };

  const handleClearFilters = () => {
    setProductPagedQuery((prevState) => ({ ...prevState, productCategory: "", pageIndex: "1", sortingColumnName: "id", sortDirection: "asc", name: "" }));
    setSearchParams("");
  };

  return (
    <PageLayout
      currentPage={AppRouteEnum.SHOP}
    >

      <Grid
        container
        height={isDownLg ? "auto" : "160vh"}
        direction="column"
        justifyContent="flex-start"
        rowSpacing={3}
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
          marginTop="3vh"
        >
          <Typography
            variant="h1"
            color="primary"
          >
            Welcome to Shop!
          </Typography>
        </Grid>
        {
          productPagedQuery.name &&
          <Grid
            item
            xs={.2}
            container
            justifyContent="left"
            paddingLeft={isDownLg ? "" : "27vw"}
          >
            <Typography
              variant="h5"
              color={theme.palette.primary.contrastText}
            >
              «
              {productPagedQuery.name}
              »
              {!productsIsLoading && productsIsSuccess && pagedProducts && " - found " + pagedProducts.total + " products"}
            </Typography>
          </Grid>
        }
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
            alignItems="end"
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
                <MenuItem value={"id asc"}>Default</MenuItem>
                <MenuItem value={"price asc"}>Price: Low to High</MenuItem>
                <MenuItem value={"price desc"}>Price: High to Low</MenuItem>
              </Select>
            </FormControl>
          </Grid>
        </Grid>
        <Grid
          container
          item
          xs={8}
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
                !productCategoriesIsLoading && productCategoriesIsSuccess && productCategories.items &&
                <FormControl>
                  <FormLabel id="radio-categories">Category : </FormLabel>
                  <RadioGroup
                    aria-labelledby="radio-categories"
                    name="radio-buttons-group"
                    onChange={handleCategoryChange}
                    value={productPagedQuery.productCategory || ""}
                  >
                    {productCategories.items.map(item => (
                      <FormControlLabel
                        key={item.id}
                        value={item.name}
                        control={<Radio />}
                        label={item.name}
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