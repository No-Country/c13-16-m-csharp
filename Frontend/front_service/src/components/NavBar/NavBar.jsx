import React from 'react';
import styles from './NavBar.module.css';
import { Link as Anchor } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import menuActions from '../../store/menu/actions'

const {menuState} = menuActions

export default function NavBar() {
  const dispatch = useDispatch()

  function abrirMenu(){
    dispatch(menuState({state:true}))
  }

  return (
    <div className={styles.border}>
      <div className={styles.all}>
        <div className={styles.menu} onClick={abrirMenu}><i className="fa-solid fa-bars fa-xl" style={{color: '#000000'}}></i></div>
        <nav className={styles.links}>
          <Anchor to={'/servicios'}>Servicios</Anchor>
          <Anchor to={'/nosotros'}>Nosotros</Anchor>
          <Anchor to={'/aliados'}>Aliados</Anchor>
          <Anchor to={'/fotos'}>Fotos</Anchor>
        </nav>
        <div className={styles.logo}>Api-Service</div>
      </div>
    </div>
  )
}
