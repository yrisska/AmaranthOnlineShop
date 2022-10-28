import { Grid, Dialog, DialogTitle, DialogContent, DialogActions, Button, useMediaQuery, useTheme, IconButton, Divider, Typography, Box, TextField } from "@mui/material";
import { FC, Fragment } from "react";
import { CartProps } from "./Cart.types";
import CloseIcon from "@mui/icons-material/Close";
import { cartDecrementItem, cartIncrementItem, CartItemRequest, cartRemoveAll, cartRemoveItem, PostOrderRequest, RootState, selectCartItems, selectCartTotalPrice, useAppDispatch, useAppSelector, usePostOrderMutation } from "@amaranth-online-shop.react-app/redux";
import RemoveIcon from "@mui/icons-material/Remove";
import AddIcon from "@mui/icons-material/Add";
import DeleteOutlineIcon from "@mui/icons-material/DeleteOutline";
import currency from "currency.js";
import { cartStyles } from "./Cart.styles";
import { MakeOrderFormInputs, makeOrderSchema } from "../../../types";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { SubmitHandler } from "react-hook-form/dist/types";

const Cart: FC<CartProps> = ({ handleClose }) => {

  const theme = useTheme();
  const isDownMd = useMediaQuery(theme.breakpoints.down("md"));

  const cartItems = useAppSelector(selectCartItems);
  const cartTotalPrice = useAppSelector(selectCartTotalPrice);

  const dispatch = useAppDispatch();

  const { control, handleSubmit, formState: { errors } } = useForm<MakeOrderFormInputs>({
    resolver: yupResolver(makeOrderSchema)
  });

  const [updatePost, { isLoading }] = usePostOrderMutation();

  const onSubmit: SubmitHandler<MakeOrderFormInputs> = data => {
    const postOrderRequest: PostOrderRequest = {
      cartItems: cartItems.map((x): CartItemRequest => ({
        productId: x.product.id,
        quantity: x.quantity
      })),
      fullName: data.fullName,
      email: data.email,
      adress: data.adress,
      phone: data.phone,
      comments: data.comments
    };
    updatePost(postOrderRequest);
  };

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
        {...cartStyles.titleContainer}
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
            style={cartStyles.closeIcon}
          />
        </IconButton>
      </Grid>
      <Divider />
      {
        !cartItems.length ?
          <Grid
            {...cartStyles.emptyCartContainer}
          >
            <Typography
              variant="h2"
              color="gray"
            >
              Cart is empty!
            </Typography>
          </Grid>
          :
          <>
            <DialogContent>
              <Grid
                {...cartStyles.cartContainer}
              >
                <Grid
                  {...cartStyles.flexEndItemContainer}
                >
                  <Button
                    variant="outlined"
                    color="error"
                    onClick={() => dispatch(cartRemoveAll())}
                  >
                    Delete all
                  </Button>
                </Grid>
                {cartItems.map(item => (
                  <Fragment
                    key={item.product.id}
                  >
                    <Grid
                      {...cartStyles.cartItemContainer}
                    >
                      <Grid
                        item
                        xs={3}
                      >
                        <Box
                          component={"img"}
                          src="https://es.com.ua/media/catalog/product/placeholder/default/default-product-image.png?auto=webp&format=png&width=2560&height=3200&fit=cover"
                          sx={cartStyles.productImg} />
                      </Grid>

                      <Grid
                        {...cartStyles.nameQuantityContainer}
                      >
                        <Typography
                          variant="h5"
                          color="initial"
                          textAlign="justify"
                          fontSize="calc(1vmax + 10px)"
                        >
                          {item.product.name}
                        </Typography>
                        <Grid
                          {...cartStyles.quantityContainer}
                        >
                          <IconButton
                            aria-label="Decrement item"
                            onClick={() => dispatch(cartDecrementItem(item.product.id))}
                            disabled={item.quantity === 1}
                          >
                            <RemoveIcon />
                          </IconButton>
                          <Typography
                            variant="h5"
                            color="initial"
                            fontSize="calc(1vmax + 10px)"
                          >
                            {item.quantity}
                          </Typography>
                          <IconButton
                            aria-label="Increment item"
                            onClick={() => dispatch(cartIncrementItem(item.product.id))}
                          >
                            <AddIcon />
                          </IconButton>
                        </Grid>
                      </Grid>

                      <Grid
                        {...cartStyles.removePriceContainer}
                      >
                        <IconButton
                          aria-label="Remove item"
                          onClick={() => dispatch(cartRemoveItem(item.product.id))}
                        >
                          <DeleteOutlineIcon />
                        </IconButton>
                        <Typography
                          variant="h5"
                          color="initial"
                          fontSize="calc(1vmax + 10px)"
                        >
                          {currency(item.totalPrice).format()}
                        </Typography>
                      </Grid>
                    </Grid>
                    <Divider />
                  </Fragment>
                ))}
                <Grid
                  {...cartStyles.flexEndItemContainer}
                >
                  <Typography
                    variant="h5"
                    color="initial"
                    fontSize="calc(1vmax + 10px)"
                  >
                    {"Total: " + cartTotalPrice.format()}
                  </Typography>
                </Grid>
              </Grid>
              <Grid
                component="form"
                onSubmit={handleSubmit(onSubmit)}
                {...cartStyles.form}
                direction={isDownMd ? "column" : "row"}
              >
                <Controller
                  name="fullName"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      {...field}
                      label="Full Name"
                      variant="outlined"
                      sx={cartStyles.input}
                      error={!!errors.fullName}
                      helperText={errors.fullName?.message}
                    />
                  )}
                />
                <Controller
                  name="email"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      {...field}
                      label="Email"
                      variant="outlined"
                      sx={cartStyles.input}
                      error={!!errors.email}
                      helperText={errors.email?.message}
                    />
                  )}
                />
                <Controller
                  name="phone"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      {...field}
                      label="Phone"
                      variant="outlined"
                      sx={cartStyles.input}
                      error={!!errors.phone}
                      helperText={errors.phone?.message}
                    />
                  )}
                />
                <Controller
                  name="adress"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      {...field}
                      label="Adress"
                      variant="outlined"
                      sx={cartStyles.input}
                      error={!!errors.adress}
                      helperText={errors.adress?.message}
                    />
                  )}
                />
                <Controller
                  name="comments"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      {...field}
                      multiline
                      label="Comments"
                      variant="outlined"
                      sx={cartStyles.input}
                      error={!!errors.comments}
                      helperText={errors.comments?.message}
                    />
                  )}
                />
                <Button
                  variant="contained"
                  color="primary"
                  type="submit"
                  sx={cartStyles.checkoutButton}
                >
                  Checkout
                </Button>
              </Grid>
              
            </DialogContent>
          </>
      }
    </Dialog>
  );
};

export default Cart;