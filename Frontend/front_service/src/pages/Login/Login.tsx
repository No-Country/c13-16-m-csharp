import React from 'react'
import './login.css'
import logo from '../../images/logo.png'
import bg from '../../images/login-bg.png'
import { Link as Anchor } from 'react-router-dom'
import { useDispatch } from 'react-redux/es/exports'
import authActions from '../../store/auth/actions'
const { authState } = authActions

export default function Login() {
  const dispatch = useDispatch()

  function cambiarEstado(){
    dispatch(authState({state: false}))
  }

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
          <p>¿No tienes cuenta?</p><Anchor to={'#'} onClick={cambiarEstado}>Registrate</Anchor> {/* el anchor tiene que cambiar el estado en redux para pasar a registro */}
        </div>
      </div>
    </div>
  )
}
