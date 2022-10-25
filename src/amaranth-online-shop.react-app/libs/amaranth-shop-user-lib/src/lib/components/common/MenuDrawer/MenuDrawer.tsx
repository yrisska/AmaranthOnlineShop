import { Avatar, Box, Button, Divider, Drawer, Grid, IconButton, List, ListItemButton, ListItemIcon, ListItemText, useTheme, Typography, Link } from '@mui/material'
import { useState } from 'react';
import MenuIcon from '@mui/icons-material/Menu'
import { AppRouteEnum } from '../../../types';
import { Link as RouterLink } from 'react-router-dom';
import CloseIcon from '@mui/icons-material/Close';

const MenuDrawer = () => {
  const theme = useTheme();
  const [openDrawer, setOpenDrawer] = useState(false);
  return (
    <>
      <Drawer
        anchor="left"
        open={openDrawer}
        onClose={() => setOpenDrawer(false)}
      >
        <Box
          sx={{
            width: "320px",
            height: "100%",
            background: theme.palette.primary.light,
            fontSize: "1.2rem"
          }}
        >
          <Grid
            container
            bgcolor="#221F1F"
            width="320px"
            height="18%"
          >
            <Grid
              container
              justifyContent="space-between"
              alignContent="baseline"
              xs={12}
              color="white"
              margin="2vh"
            >
              <Typography
                variant="h6"
                color="white"
                margin="5px"
              >
                MENU
              </Typography>
              <IconButton
                aria-label=""
                onClick={() => setOpenDrawer(false)}
              >
                <CloseIcon style={{ color: "white" }} />
              </IconButton>
            </Grid>
            <Grid
              container
              justifyContent="space-evenly"
              xs={7}
              color="white"
              margin="2vh"
              spacing={12}
              fontSize="10px"
            >
              <Avatar>
                Y
              </Avatar>
              <Button size='small'>
                Login
              </Button>
              <Divider
                variant='middle'
                orientation='vertical'
                flexItem
                sx={{ background: "white" }}
              />
              <Button size='small'>
                Sign Up
              </Button>
            </Grid>
          </Grid>
          <Grid
            container
            direction="column"
            margin="2vh"
            rowSpacing={2}
            fontSize="1.5rem"
          >
            {Object.keys(AppRouteEnum).map((page, index) => (
              <Grid item xs={6}>
                <Link
                  component={RouterLink}
                  to={AppRouteEnum[page as keyof typeof AppRouteEnum]}
                  sx={{textDecoration: "none"}}
                >
                  {page}
                </Link>
              </Grid>
            ))}
          </Grid>
        </Box>
      </Drawer>
      <IconButton
        sx={{ color: "black", scale: "1.5", marginRight: "auto", height: "50%" }}
        onClick={() => setOpenDrawer(!openDrawer)}
      >
        <MenuIcon />
      </IconButton>
    </>
  )
}

export default MenuDrawer