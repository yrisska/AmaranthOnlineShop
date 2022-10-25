import { Box } from '@mui/system'
import { FC, PropsWithChildren } from 'react'
import Footer from '../../components/common/Footer/Footer'
import Header from '../../components/common/Header/Header'
import { pageLayoutStyles } from './PageLayout.styles'
import { PageLayoutProps } from './PageLayout.types'

export const PageLayout: FC<PropsWithChildren<PageLayoutProps>> = ({
  children,
  currentPage
}) => {


  return (
    <Box
      sx={pageLayoutStyles.root}
    >
      <Header />
      {children}
      <Footer />
    </Box>
  )
}
