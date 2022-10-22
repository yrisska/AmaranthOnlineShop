import { Box } from '@mui/system'
import { FC, PropsWithChildren } from 'react'
import { PageLayoutProps } from './PageLayout.types'

export const PageLayout: FC<PropsWithChildren<PageLayoutProps>> = ({
  children,
  currentPage
}) => {


  return (
    <Box>
      Header
      {children}
      Footer
    </Box>
  )
}
