import React from 'react'
import './auth.css'
import Login from '../Login/Login.tsx'
import Register from '../Register/Register.tsx'
import { useSelector } from 'react-redux'

export default function Auth() {
  let store = useSelector((store:any) => store.authReducer.state) // trae desde redux el estado de auth y ver si se renderiza el inicio de sesion o el registro

  return (
    <div>
      { store ? <Login/> : <Register/> }
    </div>
  )
}
