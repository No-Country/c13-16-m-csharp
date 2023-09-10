import IndexLayout from '../layouts/IndexLayout.tsx'
import Home from './Home/Home.tsx'
<<<<<<< HEAD
import Profile from './Profile/Profile.tsx'
=======
import Auth from './Auth/Auth.tsx'
>>>>>>> 466f5e33885e200055877aff7ca4787f3b03b89a

import { createBrowserRouter } from 'react-router-dom'

export const router = createBrowserRouter([
    {
        path: '/',
        element: <IndexLayout/>,
        children: [
            { path: '/', element: <Home/> },
<<<<<<< HEAD
            { path: '/perfil', element: <Profile/> }
=======
            { path: '/auth', element: <Auth/> }
>>>>>>> 466f5e33885e200055877aff7ca4787f3b03b89a
        ]
    }
])