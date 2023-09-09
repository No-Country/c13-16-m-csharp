import IndexLayout from '../layouts/IndexLayout.tsx'
import Home from './Home/Home.tsx'

import { createBrowserRouter } from 'react-router-dom'

export const router = createBrowserRouter([
    {
        path: '/',
        element: <IndexLayout/>,
        children: [
            { path: '/', element: <Home/> }
        ]
    }
])