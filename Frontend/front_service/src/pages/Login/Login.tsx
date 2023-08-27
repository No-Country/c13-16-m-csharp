import React from 'react'
import './login.css'
import logo from '../../images/logo.png'
import bg from '../../images/login-bg.png'
import { Link as Anchor } from 'react-router-dom'

export default function Login() {
  return (
    <div className='login-hero'>
      <div className='background'>
        <img src={bg} alt='background'></img>
      </div>
      <div className='login-data'>
        <img src={logo} alt='logo'></img>
        <div className='login-title'>
          <h2>Iniciar Sesión</h2>
          <form className='login-form'>
            <input type='text' name='usuario' placeholder='Usuario'></input>
            <input type='password' name='contraseña' placeholder='Contraseña'></input>
            <input className='submit' type='submit' value={'Ingresar'}></input>
          </form>
        </div>
        <div className='switch-auth'>
          <p>¿No tienes cuenta?</p><Anchor to={'#'}>Registrate</Anchor>
        </div>
      </div>
    </div>
  )
}
