import React from 'react'
import './login.css'
import logo from '../../images/logo.webp'
import bg from '../../images/login-bg.webp'
import { Link as Anchor } from 'react-router-dom'
import { useDispatch } from 'react-redux/es/exports'
import authActions from '../../store/auth/actions'
const { authState } = authActions

export default function Login() {
  const dispatch = useDispatch()

  function cambiarEstado(){
    dispatch(authState({state: false}))
  }

  function login(e:any){
    e.preventDefault()
    const data = {
      usuario: e.target[0].value,
      contraseña: e.target[1].value
    }
    console.log(data)
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
          <form className='login-form' onSubmit={login}>
            <input type='text' name='usuario' placeholder='Usuario' required></input>
            <input type='password' name='contraseña' placeholder='Contraseña' required></input>
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
