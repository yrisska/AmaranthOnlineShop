import { useGetPagedProductCategoriesQuery } from "@amaranth-online-shop.react-app/redux";
import { Box, Grid, ImageList, ImageListItem, ImageListItemBar, Typography, useMediaQuery, useTheme } from "@mui/material";
import { createSearchParams, useNavigate } from "react-router-dom";
import { PageLayout } from "../../layout";
import { AppRouteEnum } from "../../types";

export const HomePageContainer = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));

  const {
    data: pagedProductCategories,
    isLoading: productCategoriesIsLoading,
    isSuccess: productCategoriesIsSuccess,
  } = useGetPagedProductCategoriesQuery({
    pageIndex: "1",
    pageSize: "3",
  });

  const navigate = useNavigate();
  const handleCategorySelect = (category: string) => {
    navigate({
      pathname: AppRouteEnum.SHOP,
      search: createSearchParams({
        category: category
      }).toString()
    });
  };

  return (
    <PageLayout
      currentPage={AppRouteEnum.HOME}
    >
      <Grid
        container
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
          width="100%"
          justifyContent="center"
          alignItems="center"
          height="30vh"
        >
          <Typography
            variant="h1"
            color="primary"
            textAlign="center"
          >
            Join Amaranth Family
          </Typography>
        </Grid>
        {
          !productCategoriesIsLoading && productCategoriesIsSuccess && pagedProductCategories.items &&
          <Grid
            item
            container
            width="90%"
            justifyContent="center"
            alignItems="center"
          >
            <ImageList
              cols={isDownLg ? 1 : 3}
              gap={25}
            >
              {pagedProductCategories.items.map(item => (
                <ImageListItem
                  key={item.id}
                  sx={{
                    cursor: "pointer",
                    overflow: "hidden",
                    "&:hover > img": {
                      transform: "scale(1.15)",
                    }
                  }}
                >
                  <Box

                    sx={{
                      height: isDownLg ? "30vh" : "25vh",
                      [theme.breakpoints.down("sm")]: {
                        height: "20vh"
                      },
                      transform: "scale(1)",
                      transition: ".3s ease-in-out",
                    }}
                    component="img"
                    alt={item.name}
                    src={item.imageUri}
                    onClick={() => handleCategorySelect(item.name)}
                  />
                  <ImageListItemBar
                    title={item.name}
                  >
                  </ImageListItemBar>
                </ImageListItem>

              ))}
            </ImageList>
          </Grid>
        }
        <Grid
          container
          item
          width="100%"
          height="25vh"
          direction="column"
          rowGap="1vh"
          justifyContent="center"
          alignItems="center"
          bgcolor={theme.palette.primary.main}
        >
          <Typography
            variant="h3"
            color="white"
          >
            Our difference:
          </Typography>
          <Typography
            variant="h6"
            color="white"
          >
            1. Locally, family-owned.
          </Typography>
          <Typography
            variant="h6"
            color="white"
          >
            2. First in New Products.
          </Typography>
          <Typography
            variant="h6"
            color="white"
          >
            3. Expertise Beyond the Algorithm.
          </Typography>
        </Grid>

      </Grid>
    </PageLayout >
  );
};

export default HomePageContainer;