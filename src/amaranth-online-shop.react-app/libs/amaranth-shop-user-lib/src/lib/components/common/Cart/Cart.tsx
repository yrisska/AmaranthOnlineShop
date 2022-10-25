import { Grid, Dialog, DialogTitle, DialogContent, DialogActions, Button, useMediaQuery, useTheme, IconButton, Divider, Typography, Box } from '@mui/material'
import { FC } from 'react'
import { CartProps } from './Cart.types'
import CloseIcon from '@mui/icons-material/Close';
import { cartDecrementItem, cartIncrementItem, cartRemoveAll, cartRemoveItem, RootState, selectCartItems, selectCartTotalPrice, useAppDispatch, useAppSelector } from '@amaranth-online-shop.react-app/redux';
import RemoveIcon from '@mui/icons-material/Remove';
import { useDispatch, useSelector } from 'react-redux';
import AddIcon from '@mui/icons-material/Add';
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import currency from 'currency.js';

const Cart: FC<CartProps> = ({ handleClose }) => {

  const theme = useTheme();
  const isDownMd = useMediaQuery(theme.breakpoints.down("md"));

  const cartItems = useAppSelector(selectCartItems);
  const cartTotalPrice = useAppSelector(selectCartTotalPrice);

  const dispatch = useAppDispatch();

  return (
    <Dialog
      open={true}
      onClose={handleClose}
      aria-labelledby="title"
      fullScreen={isDownMd}
      maxWidth="md"
      fullWidth={true}
    >
      <Grid
        container
        justifyContent="space-between"
        alignItems="center"
        paddingX="1vw"
      >
        <DialogTitle
          variant="h5"
          id="title"
        >
          Cart
        </DialogTitle>
        <IconButton
          aria-label="Close"
          onClick={handleClose}
        >
          <CloseIcon
            style={{ scale: "1.3" }}
          />
        </IconButton>
      </Grid>
      <Divider />
      {
        !cartItems.length ?
          <Grid
            container
            justifyContent="center"
            alignItems="center"
            height="40vh"
          >
            <Typography variant="h2" color="gray">
              Cart is empty!
            </Typography>
          </Grid>
          :
          <>
            <DialogContent>
              <Grid
                container
                direction="column"
                width="100%"
                paddingRight="2vh"
              >
                <Grid item container xs={12} justifyContent="flex-end">
                  <Button variant="outlined" color="primary" onClick={() => dispatch(cartRemoveAll())}>
                    Delete all
                  </Button>
                </Grid>
                {cartItems.map(item => (
                  <Grid
                    key={item.product.id}
                    item
                    container
                    alignItems="center"
                    justifyContent="space-between"
                  >
                    <Grid item xs={3}>
                      <Box
                        component={"img"}
                        src="https://es.com.ua/media/catalog/product/placeholder/default/default-product-image.png?auto=webp&format=png&width=2560&height=3200&fit=cover"
                        sx={{
                          aspectRatio: "1",
                          width: "100%",
                          height: "auto"
                        }}
                      />
                    </Grid>

                    <Grid item xs={3}>
                      <Typography variant="h5" color="initial">
                        {item.product.name}
                      </Typography>
                    </Grid>
                    <Grid item xs={3} container justifyContent="space-around">
                      <IconButton aria-label="Decrement item" onClick={() => dispatch(cartDecrementItem(item.product.id))} disabled={item.quantity === 1}>
                        <RemoveIcon />
                      </IconButton>
                      <Typography variant="h5" color="initial">
                        {item.quantity}
                      </Typography>
                      <IconButton aria-label="Increment item" onClick={() => dispatch(cartIncrementItem(item.product.id))}>
                        <AddIcon />
                      </IconButton>
                    </Grid>
                    <Grid item xs={2} container justifyContent="center">
                      <Typography variant="h5" color="initial">
                        {currency(item.totalPrice).format()}
                      </Typography>
                    </Grid>

                    <Grid item xs={1} container justifyContent="flex-end">
                      <IconButton aria-label="Remove item" onClick={() => dispatch(cartRemoveItem(item.product.id))}>
                        <DeleteOutlineIcon />
                      </IconButton>
                    </Grid>



                  </Grid>
                ))}
                <Grid
                  item
                  container
                  justifyContent="flex-end"
                >
                  <Typography variant="h5" color="initial">
                    {cartTotalPrice.format()}
                  </Typography>
                </Grid>
              </Grid>
            </DialogContent>
            <DialogActions>

            </DialogActions>
          </>
      }

    </Dialog>
  )
}

export default Cart