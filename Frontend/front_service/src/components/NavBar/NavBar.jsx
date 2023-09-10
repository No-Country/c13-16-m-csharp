import React from 'react';
import styles from './NavBar.module.css';
import { Link as Anchor } from 'react-router-dom';

export default function NavBar() {
  return (
    <div className={styles.border}>
      <div className={styles.all}>
        <div className={styles.logo}>Api-Service</div>
        <nav className={styles.links}>
          <Anchor to={'/servicios'}>Servicios</Anchor>
          <Anchor to={'/nosotros'}>Nosotros</Anchor>
          <Anchor to={'/aliados'}>Aliados</Anchor>
          <Anchor to={'/fotos'}>Fotos</Anchor>
        </nav>
        <button className={styles.button}>Contact</button>
      </div>
    </div>
  )
}
