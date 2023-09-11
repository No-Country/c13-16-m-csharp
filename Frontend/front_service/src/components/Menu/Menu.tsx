import React from 'react'
import './menu.css'
import { Link as Anchor } from 'react-router-dom'
import { useDispatch } from 'react-redux';
import menuActions from '../../store/menu/actions'

const {menuState} = menuActions

export default function Menu() {
  const dispatch = useDispatch()

  function cerrarMenu(){
    dispatch(menuState({state:false}))
  }

  return (
    <div className='menu-main'>
      <div className='menu-container'>
        <section className='menu-title'>
          <h1>Menu</h1>
          <i className="fa-solid fa-x closeMenu" onClick={cerrarMenu} style={{color: '#fff'}}></i>
        </section>
        <nav>
          <Anchor to={'/autenticacion'}>Registrar - Iniciar Sesión</Anchor>
        </nav>
      </div>
    </div>
  )
}
