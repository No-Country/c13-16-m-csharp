import React from 'react'
import './auth.css'
import Login from '../Login/Login.tsx'
import Register from '../Register/Register.tsx'

// traer desde redux el estado de auth y ver si se renderiza el inicio de sesion o el registro

export default function Auth() {
  return (
    <div>
        <Register/>
        {/* <Login/> */}
    </div>
  )
}
