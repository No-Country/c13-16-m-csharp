import React from 'react';
import styles from './Blog.module.css';
import BlogSectionImage from '../../assets/BlogSectionImage.webp';
import Client1 from '../../assets/Client1.webp';
import Client2 from '../../assets/Client2.webp';
import Client3 from '../../assets/Client3.webp';
import Worker1 from '../../assets/Worker1.webp';
import Worker2 from '../../assets/Worker2.webp';
import Worker3 from '../../assets/Worker3.webp';

export default function Blog() {
  return (
    <div className={styles.all}>
      <div className={styles.border}>
        <div className={styles.bg}>
          <h1>Testimonios</h1>
          <div className={styles.hands}>
            <div>
              <h2>Lo que nuestros clientes y trabajadores tienen que decir</h2>
              <p>Explora las experiencias compartidas por aquellos que han sido parte de nuestra comunidad.
                Desde la perspectiva de nuestros valiosos clientes y dedicados trabajadores, estas historias
                capturan la esencia de lo que hacemos.
              </p>
            </div>
            <img alt='hands' src={BlogSectionImage} />
          </div>
          <div>
            <h1>Clientes</h1>
            <div className={styles.clients}>
              <div>
                <img alt='cliente 1' src={Client1} />
                <p>Experiencia con el servicio y como le fue con el trabajador</p>
                <h3>Nombre 1</h3>
              </div>
              <div>
                <img alt='cliente 2' src={Client2} />
                <p>Experiencia con el servicio y como le fue con el trabajador</p>
                <h3>Nombre 2</h3>
              </div>
              <div>
                <img alt='cliente 3' src={Client3} />
                <p>Experiencia con el servicio y como le fue con el trabajador</p>
                <h3>Nombre 3</h3>
              </div>
            </div>
          </div>
          <div>
            <h1>Trabajadores</h1>
            <div className={styles.workers}>
              <div>
                <img className={styles.worker__1} alt='trabajador 1' src={Worker1} />
                <p>Experiencia con el trabajo realizado</p>
                <h3>Nombre 1</h3>
              </div>
              <div>
                <img alt='trabajador 2' src={Worker2} />
                <p>Experiencia con el trabajo realizado</p>
                <h3>Nombre 2</h3>
              </div>
              <div>
                <img alt='trabajador 3' src={Worker3} />
                <p>Experiencia con el trabajo realizado</p>
                <h3>Nombre 3</h3>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
