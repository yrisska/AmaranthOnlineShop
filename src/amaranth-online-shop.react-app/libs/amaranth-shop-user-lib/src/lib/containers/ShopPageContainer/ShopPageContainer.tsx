import { Box, Grid, useMediaQuery, useTheme, Typography } from '@mui/material'
import { useDispatch } from 'react-redux'
import ProductList from '../../components/common/ProductList/ProductList'
import { PageLayout } from '../../layout'
import { AppRouteEnum } from '../../types'

export const ShopPageContainer = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));


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
            <ProductList />
          </Grid>
        </Grid>
      </Grid>
    </PageLayout>
  )
}

export default ShopPageContainer