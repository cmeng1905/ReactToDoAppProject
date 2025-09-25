import { createRoot } from 'react-dom/client'
import { store } from './store/store.ts'
import { Provider } from 'react-redux'
import { RouterProvider } from 'react-router'
import { router } from './router/routes.tsx'


createRoot(document.getElementById('root')!).render(
  <>
    {/* <Provider store={store}> */}
    <RouterProvider router={router} />
    {/* </Provider> */}
  </>,
)
