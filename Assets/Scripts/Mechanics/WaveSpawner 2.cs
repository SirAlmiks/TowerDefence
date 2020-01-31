using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves; //массив разных типов волн
    public Transform spawnPoint; //Исходная точка где враги будут появляться
    public Text waveCountdownText; //Отображение времени до следующей волны
    public Text surWaveText; //Отображение текущей волны
    public Text enemiesAliveText;
    public float timeBetweenWaves = 5f; //максимальная задержка между волнами
    private float countdown = 10f; //время ожидания следующей волны
    public int wavesCount = 0; //общее количество волн
    public static int enemiesAlive = 0; //всего врагов на карте в текущий момент
    public static int healthMult = 1; //множитель жизни врагов
    public int startHealthMult = 1; //множитель жизни врагов

    void Start() {
        healthMult = startHealthMult;
    }
    
    void Update()
    {
        enemiesAliveText.text = enemiesAlive.ToString();
        if (enemiesAlive > 0) {
            return;
        }

        if (countdown <= 0f) {
            StartCoroutine(StandartWave()); //запуск функции с паузой
            StartCoroutine(HeavyWave());
            StartCoroutine(FastWave());
            if (wavesCount % 5 == 0) //Каждую 5 волну спавн боссов
                StartCoroutine(BossWave());
            if (wavesCount % 10 == 0)
                healthMult++; //увеличение живучести врагов каждые 10 волн
            
            countdown = timeBetweenWaves;
            wavesCount++;
            PlayerStats.Waves++;
            surWaveText.text = PlayerStats.Waves.ToString();
            return;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //Проверка, что откат не будет меньше нуля

        waveCountdownText.text = string.Format("{0:00.00}",countdown); //отображение числа в виде в секунд с милисекундами       
    }
    IEnumerator StandartWave() {
                
        Wave wave = waves[0];
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        wave.count++;
    }

    //Создание волн враго по типам
    IEnumerator HeavyWave() {
                
        Wave wave = waves[1];
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        if (wavesCount > 5 && wavesCount % 3 == 0) //наращивание количества врагов с волнами
            wave.count++;
    }

    IEnumerator FastWave() {
                
        Wave wave = waves[2];
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        if (wavesCount > 5 && wavesCount % 3 == 0)
        wave.count += 2;
    }
    IEnumerator BossWave() {
                
        Wave wave = waves[3];
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        wave.count++;
    }
    
    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
