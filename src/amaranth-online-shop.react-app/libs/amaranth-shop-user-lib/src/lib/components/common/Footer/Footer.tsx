import { Box, useTheme } from '@mui/material'
import React from 'react'

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
      Footer
    </Box>
  )
}

export default Footer