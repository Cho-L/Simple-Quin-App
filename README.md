# Simple Quiz App

Unity와 C#을 활용하여 제작한 **타이머 기반 퀴즈 게임**입니다.

사용자는 제한 시간 내에 4개의 선택지 중 정답을 선택해야 하며, 문제는 랜덤하게 출제됩니다.
문제 데이터는 Unity의 `ScriptableObject`를 활용하여 코드와 분리해 관리했습니다.

## 🎮 Project Overview

* **Engine:** Unity 2022.3.27f1
* **Language:** C#
* **UI:** Unity UI, TextMeshPro
* **Data Management:** ScriptableObject
* **Platform:** PC

## ✨ 주요 기능

### 1. 랜덤 문제 출제

등록된 문제 목록에서 문제를 랜덤으로 선택하여 출제합니다.

한 번 출제된 문제는 리스트에서 제거하여 동일한 문제가 반복해서 출제되지 않도록 구현했습니다.

### 2. 제한 시간 시스템

각 문제마다 제한 시간을 설정할 수 있습니다.

* 문제 풀이 시간: 30초
* 정답 결과 표시 시간: 10초
* 시간 종료 시 자동으로 다음 문제 진행

`Timer` 클래스에서 문제 풀이 상태와 결과 표시 상태를 관리하고, `fillAmount`를 이용해 UI에 남은 시간을 표시합니다.

### 3. 정답 / 오답 처리

사용자가 답안을 선택하면 즉시 정답 여부를 판단합니다.

* 정답 선택 → `Correct Answer!` 표시
* 오답 선택 → 정답 표시
* 정답 버튼의 Sprite 변경을 통한 시각적 피드백
* 답변 이후 모든 버튼 비활성화

### 4. ScriptableObject 기반 문제 데이터 관리

문제 데이터를 `QuestionSO` ScriptableObject로 분리했습니다.

```text
QuestionSO
 ├─ Question
 ├─ Answer 1
 ├─ Answer 2
 ├─ Answer 3
 ├─ Answer 4
 └─ Correct Answer Index
```

이를 통해 문제 데이터를 코드에서 직접 수정하지 않고 Unity Editor에서 개별 Asset으로 관리할 수 있도록 구성했습니다.

## 🏗️ 주요 구조

```text
Quiz
 ├─ QuestionSO 목록 관리
 ├─ 랜덤 문제 선택
 ├─ 문제 및 답안 UI 출력
 ├─ 사용자 답안 처리
 └─ 정답 결과 표시

Timer
 ├─ 문제 풀이 시간 관리
 ├─ 결과 표시 시간 관리
 ├─ 시간 진행률 계산
 └─ 다음 문제 전환

QuestionSO
 ├─ 문제 데이터
 ├─ 선택지 데이터
 └─ 정답 인덱스
```

## 🔄 게임 진행 흐름

```text
게임 시작
   ↓
문제 랜덤 선택
   ↓
문제 및 선택지 출력
   ↓
제한 시간 동안 답안 선택
   ↓
┌───────────────┐
│ 답안 선택     │
└───────┬───────┘
        ↓
    정답 여부 확인
        ↓
정답 표시 / 오답 처리
        ↓
버튼 비활성화
        ↓
결과 표시
        ↓
다음 문제
```

## 💻 구현 포인트

### Quiz

`Quiz` 클래스에서 퀴즈의 전체적인 진행을 관리합니다.

* 문제 목록 관리
* 랜덤 문제 선택
* 답안 UI 갱신
* 답안 선택 처리
* 정답 Sprite 변경
* Timer와 연동

### Timer

`Timer` 클래스에서는 문제 풀이 단계와 결과 표시 단계를 구분하여 타이머를 관리합니다.

```text
문제 풀이
30초
 ↓
시간 종료
 ↓
정답 공개
10초
 ↓
다음 문제
```

### QuestionSO

`ScriptableObject`를 사용하여 문제 데이터를 게임 로직과 분리했습니다.

이를 통해 새로운 문제를 추가할 때 C# 코드를 수정하지 않고 Unity Editor에서 새로운 Question Asset을 생성하여 데이터를 추가할 수 있습니다.

## 🛠️ 사용 기술

* C#
* Unity
* Unity UI
* TextMeshPro
* ScriptableObject
* Coroutine / Update 기반 게임 로직
* Git / GitHub

## 📌 학습 및 구현 목표

이 프로젝트를 통해 Unity에서 다음과 같은 기본적인 게임 시스템 구현 방법을 학습하고 적용했습니다.

* Unity UI 시스템 활용
* C#을 이용한 게임 로직 구현
* ScriptableObject를 이용한 데이터 관리
* 게임 상태에 따른 UI 제어
* Timer 시스템 구현
* 랜덤 데이터 선택
* Git을 이용한 프로젝트 버전 관리

## 📷 Screenshots

> 게임 플레이 화면 및 UI 스크린샷을 추가할 예정입니다.

## 🔗 Repository

[GitHub Repository](https://github.com/Cho-L/Simple-Quin-App)
