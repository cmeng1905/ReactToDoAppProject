import { ToastContainer } from 'react-toastify'
import CssBaseline from '@mui/material/CssBaseline'
import { Outlet } from 'react-router'
import { Box, Container, Stack } from '@mui/material'
import Header from './Header'

function App() {
  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <CssBaseline />
      <Header />
      <Container sx={{ pt: 2, display: 'flex', alignItems: 'center', justifyContent: 'center', height: '100vh' }}>
        <Stack alignItems="center"
          sx={{
            width: "70%",
            border: '1px solid #ccc', pt: 2,
            bgcolor: '#f5f5f5',
            height: '100vh',
          }}>
          <Outlet />
        </Stack>
      </Container>
    </>
  )
}

export default App
