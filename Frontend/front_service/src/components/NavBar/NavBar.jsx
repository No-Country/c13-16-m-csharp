import React from 'react';
import styles from './NavBar.module.css';

export default function NavBar() {
  return (
    <div className={styles.border}>
      <div className={styles.all}>
        <div className={styles.logo}>Api-Service</div>
        <div className={styles.links}>
          <div>Servicios</div>
          <div>Nosotros</div>
          <div>Aliados</div>
          <div>Fotos</div>
        </div>
        <button className={styles.button}>Contact</button>
      </div>
    </div>
  )
}
