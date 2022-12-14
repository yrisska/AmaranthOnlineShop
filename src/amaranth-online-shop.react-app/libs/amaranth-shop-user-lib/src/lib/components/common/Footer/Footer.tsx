import { Box, useTheme, Typography } from "@mui/material";

const Footer = () => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        width: "100%",
        height: "110px",
        background: theme.palette.primary.light,
        position: "sticky",
        bottom: "0",
        left: "0",
        display: "flex",
        flexFlow: "column",
        alignItems: "center",
        justifyContent: "center",
        overflow: "hidden"
      }}
    >
      <Typography
        variant="h6"
        color="initial"
      >
        © Amaranth Online Shop
      </Typography>
    </Box >
  );
};

export default Footer;